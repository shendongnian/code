        static sbyte AddOverflowHelper(sbyte x, sbyte y, ref bool overflow) {
            var sum = (sbyte)(x + y);
            // x + y overflows if sign(x) ^ sign(y) != sign(sum)
            overflow |= ((x ^ y ^ sum) & sbyte.MinValue) != 0;
            return sum;
        }
        /// <summary>
        /// Multiplies two Fix8 numbers.
        /// Deals with overflow by saturation.
        /// </summary>
        public static Fix8 operator *(Fix8 x, Fix8 y) {
            // Using the cross-multiplication algorithm, for learning purposes.
            // It would be both trivial and much faster to use an Int16, but this technique
            // won't work for a Fix64, since there's no Int128 or equivalent (and BigInteger is too slow).
            sbyte xl = x.m_rawValue;
            sbyte yl = y.m_rawValue;
            byte xlo = (byte)(xl & 0x0F);
            sbyte xhi = (sbyte)(xl >> 4);
            byte ylo = (byte)(yl & 0x0F);
            sbyte yhi = (sbyte)(yl >> 4);
            byte lolo = (byte)(xlo * ylo);
            sbyte lohi = (sbyte)((sbyte)xlo * yhi);
            sbyte hilo = (sbyte)(xhi * (sbyte)ylo);
            sbyte hihi = (sbyte)(xhi * yhi);
            byte loResult = (byte)(lolo >> 4);
            sbyte midResult1 = lohi;
            sbyte midResult2 = hilo;
            sbyte hiResult = (sbyte)(hihi << 4);
            bool overflow = false;
            // Check for overflow at each step of the sum, if it happens overflow will be true
            sbyte sum = AddOverflowHelper((sbyte)loResult, midResult1, ref overflow);
            sum = AddOverflowHelper(sum, midResult2, ref overflow);
            sum = AddOverflowHelper(sum, hiResult, ref overflow);
            bool opSignsEqual = ((xl ^ yl) & sbyte.MinValue) == 0;
            
            // if signs of operands are equal and sign of result is negative,
            // then multiplication overflowed positively
            // the reverse is also true
            if (opSignsEqual) {
                if (sum < 0 || (overflow && xl > 0)) {
                    return MaxValue;
                }
            }
            else {
                if (sum > 0) {
                    return MinValue;
                }
                // If signs differ, both operands' magnitudes are greater than 1,
                // and the result is greater than the negative operand, then there was negative overflow.
                sbyte posOp, negOp;
                if (xl > yl) {
                    posOp = xl;
                    negOp = yl;
                }
                else {
                    posOp = yl;
                    negOp = xl;
                }
                if (sum > negOp && negOp < -(1 << 4) && posOp > (1 << 4)) {
                    return MinValue;
                }
            }
            // if the top 4 bits of hihi (unused in the result) are neither all 0s nor 1s,
            // then this means the result overflowed.
            sbyte topCarry = (sbyte)(hihi >> 4);
            // -17 (-1.0625) is a problematic value which never causes overflow but messes up the carry bits
            if (topCarry != 0 && topCarry != -1 && xl != -17 && yl != -17) {
                return opSignsEqual ? MaxValue : MinValue;
            }
            // Round up if necessary, but don't overflow
            var lowCarry = (byte)(lolo << 4);
            if (lowCarry >= 0x80 && sum < sbyte.MaxValue) {
                ++sum;
            }
            return new Fix8(sum);
        }
