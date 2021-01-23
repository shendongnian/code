        /// <summary>
        /// Get a unique reference number.
        /// </summary>
        /// <returns></returns>
        public string GetUniqueReferenceNumber(char firstChar)
        {
            var ticks = DateTime.Now.Ticks;
            var ticksString = ticks.ToString();
            var ticksSubString = ticksString.Substring((ticksString.Length - 15 > 0) ? ticksString.Length - 15 : 0); 
            if (this.currentTicks.Equals(ticks))
            {
                this.currentReference++;
                if (this.currentReference >= 9999)
                {
                    // Only when there are very fast computers.
                    System.Threading.Thread.Sleep(1);
                }
                
                return (firstChar + ticksSubString + this.currentReference.ToString("D4")).PadRight(20, '9');
            }
            this.currentReference = -1;
            this.currentTicks = ticks;
            return (firstChar + ticksSubString).PadRight(20, '9');
        }
