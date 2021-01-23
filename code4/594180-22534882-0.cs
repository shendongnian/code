            int num = ((sourceRect.Width * this.Format.BitsPerPixel) + 7) / 8;
            if (stride < num)
            {
                throw new ArgumentOutOfRangeException("stride", MS.Internal.PresentationCore.SR.Get("ParameterCannotBeLessThan", new object[] { num }));
            }
            int num2 = (stride * (sourceRect.Height - 1)) + num;
            if (bufferSize < num2)
            {
                throw new ArgumentOutOfRangeException("buffer", MS.Internal.PresentationCore.SR.Get("ParameterCannotBeLessThan", new object[] { num2 }));
            }
