    public partial class MData
    {
        public int ReturnAnInt()
        {
            int result;
            bool specified;
            this.ReturnAnInt(out result, out specified);
            if (!specified) throw new InvalidOperationException();
            return result;
        }
    }
