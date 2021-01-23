	For the consecutive numbers, we would met
	> 1 zeros per 10
	>
	> 10 zeros per 100
	>
	> 100 zeros per 1000
	and so on. The count of zeros we would met can be calculated with the following code: 
		static int CountOfZeros(int n, int r=10) {
			var powerSeries=n>0?1:0;
			for(var i=0; n-->0; ++i) {
				var geometricSeries=(1-Pow(r, 1+n))/(1-r);
				powerSeries+=geometricSeries*Pow(r-1, 1+i);
			}
			return powerSeries;
		}
	For `n` is the count of digits, `r` is the radix. The number would be a [power series] which calculated from a [geometric series] and plus 1 for the `0`. 
	For example, the numbers of 4 digits, the zeros we would met are: 
	>(1)+(((1*9)+11)*9+111)*9 = (1)+(1*9*9*9)+(11*9*9)+(111*9) = 2620 
	**However**, with this implementation, we do **not** really skip the calculation of numbers contains zero, since I've found that the multiplication with zeros would **not** cause much impact of performance. I've tried another partial implementation which the zeros **do** matter: 
		using System.Collections.Generic;
		using System.Linq;
		using System;
		public static partial class NumericExtensions {
			public static void NumberIteration(
					this int value, Action<int, int[]> delg, int radix=10) {
				var digits=DigitIterator(value, radix).ToArray();
				var last=digits.Length-1;
				var emptyArray=new int[] { };
				var pow=(Func<int, int, int>)((x, y) => (int)Math.Pow(x, 1+y));
				var weights=Enumerable.Repeat(radix, last-1).Select(pow).ToArray();
				for(int complement=radix-1, i=value, j=i; i>0; i-=1)
					if(i>j)
						delg(i, emptyArray);
					else if(0==digits[0]) {
						delg(i, emptyArray);
						var k=0;
						for(; k<last&&0==digits[k]; k+=1)
							;
						var y=(digits[k]-=1);
						if(last==k||0!=y) {
							if(0==y) { // implied last==k
								digits=new int[last];
								last-=1;
							}
							for(; k-->0; digits[k]=complement)
								;
						}
						else {
							j=i-weights[k-1];
						}
					}
					else {
						delg(i, digits); // number which doesn't contain zero(s)
						digits[0]-=1;
					}
				delg(0, emptyArray);
			}
			static IEnumerable<int> DigitIterator(int value, int radix) {
				if(-2<radix&&radix<2)
					radix=radix<0?-2:2;
				for(int remainder; 0!=value; ) {
					value=Math.DivRem(value, radix, out remainder);
					yield return remainder;
				}
			}
		}
	The difference is because of the result of a shallow level of recursion is reused with the recursive implementation which are what we can regard as *cached*. 
