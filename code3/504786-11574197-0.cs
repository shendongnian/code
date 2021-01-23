        protected char[] CoreNewLine = new char[2]
        {
          '\r',
          '\n'
        };    
        public virtual void WriteLine(string value)
            {
              if (value == null)
              {
                this.WriteLine();
              }
              else
              {
                int length1 = value.Length;
                int length2 = this.CoreNewLine.Length;
                char[] chArray = new char[length1 + length2];
                value.CopyTo(0, chArray, 0, length1);
                if (length2 == 2)
                {
                  chArray[length1] = this.CoreNewLine[0];
                  chArray[length1 + 1] = this.CoreNewLine[1];
                }
                else if (length2 == 1)
                  chArray[length1] = this.CoreNewLine[0];
                else
                  Buffer.InternalBlockCopy((Array) this.CoreNewLine, 0, (Array) chArray, length1 * 2, length2 * 2);
                this.Write(chArray, 0, length1 + length2);
              }
            }
