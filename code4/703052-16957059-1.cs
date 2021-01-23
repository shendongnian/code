        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            var mask = (byte)parameter;
            if ((bool)value)
            {
                _targetValue |= mask;
            }
            else
            {
                if (IsSuperFlag(mask) && mask != 1)
                    _targetValue &= (byte)(mask >> 1);
                else
                {
                    // Get all flags from enum type that are no SuperFlags
                    var flags = Enum.GetValues(targetType).Cast<Enum>();
                    flags = flags.Where(x => !IsSuperFlag(System.Convert.ToByte(x)));
                    long nonSuperFlags = 0;
                    foreach (var flag in flags)
                    {
                        nonSuperFlags |= System.Convert.ToByte(flag);
                    }
                    // Now only remove everything except the nonSuperFlags
                    // and then remove the mask
                    _targetValue &= (byte)(~(_targetValue ^ nonSuperFlags | mask));
                }
            }
            return Enum.Parse(targetType, _targetValue.ToString());
        }
        private bool IsSuperFlag(byte flag)
        {
            var b = flag;
            b--;
            b |= (byte)(b >> 1);
            b |= (byte)(b >> 2);
            b |= (byte)(b >> 4);
            b |= (byte)(b >> 8);
            return b == flag;
        }
