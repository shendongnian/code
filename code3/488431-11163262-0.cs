    interface IWibbler { void Wibble&lt;T>(T param, int param) where T : I1,I2; }
    interface IWobbler { void Wobble&lt;T>(T param, string param) where T: I1,I2; }
    private struct WibbleWobbleDelegateSet 
    {
        public Action&lt;IWibbler, int> Wibble;
        public Action&lt;IWobbler, string> Wobble;
        static WibbleWobbleDelegateSet Create&lt;T>(T param) where T: I1, I2
        {
            var ret = new WibbleWobbleDelegateSet ();
            ret.Wibble = (IWibbler wibbler, int p2) => { wibbler.Wibble&lt;T>(param, p2); };
            ret.Wobble = (IWobbler wobbler, string p2) => { wobbler.Wobble&lt;T>(param, p2); };
            return ret;
        }
    }
