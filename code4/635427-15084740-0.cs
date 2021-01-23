     public sealed class ScanReader
    {
        #region Delegates
        public delegate void _DataLoaded(string ScannedData);
        #endregion
        private readonly double MyMaxMillisecondsBetweenPress;
        private readonly List<Regex> MyRegex;
        private readonly Timer TimeToNextKeyPress = new Timer();
        private string CardBuff = string.Empty;
        private bool FirstKeyPress = true;
        private DateTime Stamp;
        /// <summary>
        /// ScanReader constructor
        /// </summary>
        /// <param name="Press"> Form where KeyPreview = true </param>
        /// <param name="Regs"> Regular expressions for filtering scanned data</param>
        /// <param name="MaxMillisecondsBetweenPress"> The maximum time between pressing the keys in milliseconds, default = 60 </param>
        public ScanReader(Form form, List<Regex> Regs = null, double MaxMillisecondsBetweenPress = 0)
        {
            MyRegex = Regs ?? null;
            MyMaxMillisecondsBetweenPress = MaxMillisecondsBetweenPress == 0 ? 60 : MaxMillisecondsBetweenPress;
            form.KeyPress += KeyPressed;
            TimeToNextKeyPress.Interval =
                Convert.ToInt32(MyMaxMillisecondsBetweenPress + MyMaxMillisecondsBetweenPress*0.2);
            TimeToNextKeyPress.Tick += TimeToNextKeyPress_Tick;
        }
        public event _DataLoaded OnDataLoaded;
        private void TimeToNextKeyPress_Tick(object sender, EventArgs e)
        {
            TimeToNextKeyPress.Stop();
            if (MyRegex.Count > 0)
            {
                foreach (Regex reg in MyRegex)
                {
                    if (reg.IsMatch(CardBuff))
                    {
                        OnDataLoaded(CardBuff);
                        return;
                    }
                }
            }
            else
                OnDataLoaded(CardBuff);
        }
        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (FirstKeyPress)
            {
                Stamp = DateTime.Now;
                FirstKeyPress = false;
                CardBuff = e.KeyChar.ToString();
            }
            else
            {
                if ((DateTime.Now - Stamp).TotalMilliseconds < MyMaxMillisecondsBetweenPress)
                {
                    Stamp = DateTime.Now;
                    CardBuff += e.KeyChar;
                }
                else
                {
                    Stamp = DateTime.Now;
                    CardBuff = e.KeyChar.ToString();
                }
            }
            TimeToNextKeyPress.Stop();
            TimeToNextKeyPress.Start();
        }
    }
