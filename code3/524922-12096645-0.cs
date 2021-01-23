    public class Dars
    {
        public float OpBal      { get; set; }
        public float PlNeOrRec  { get; set; }
        public float MiCaCol    { get; set; }
        public float MiDeCol    { get; set; }
        public float MiWrOff    { get; set; }
        public float ClBal      { get; set; }
        public IEnumerable<float> GetValues()
        {
            yield return OpBal;
            yield return PlNeOrRec;
            yield return MiCaCol;
            yield return MiDeCol;
            yield return MiWrOff;
            yield return ClBal;
        }
        public float Tot
        {
            get { return OpBal+ PlNeOrRec+ MiCaCol + MiDeCol + MiWrOff; }
        }
    }
