    public class Dars : IEnumerable
    {
        public float OpBal { get; set; }
        public float PlNeOrRec { get; set; }
        public float MiCaCol { get; set; }
        public float MiDeCol { get; set; }
        public float MiWrOff { get; set; }
        public float ClBal { get; set; }
        public float Tot
        {
            get { return OpBal + PlNeOrRec + MiCaCol + MiDeCol + MiWrOff; }
        }
        public IEnumerator GetEnumerator()
        {
            yield return this.OpBal;
            yield return this.PlNeOrRec;
            yield return this.MiCaCol;
            yield return this.MiDeCol;
            yield return this.MiWrOff;
            yield return this.ClBal;
            yield return this.Tot;
        }
    }
