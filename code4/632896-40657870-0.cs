        /// <summary>
        /// Get a unique reference number.
        /// </summary>
        /// <returns></returns>
        public string GetUniqueReferenceNumber(char firstChar)
        {
            var ticks = DateTime.Now.Ticks;
            if (this.currentTicks.Equals(ticks))
            {
                this.currentReference++;
                if (this.currentReference >= 1000)
                {
                    // Only when there are very fast computers.
                    System.Threading.Thread.Sleep(1);
                }
                return firstChar + ticks.ToString().Truncate(16) + this.currentReference.ToString("D3");
            }
            // Max length of 20
            this.currentReference = -1;
            this.currentTicks = ticks;
            return (firstChar + ticks.ToString().Truncate(19)).PadRight(20, '0');
        }
