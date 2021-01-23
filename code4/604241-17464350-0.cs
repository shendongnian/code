    public class ResumeContainer
    {
        public double SommeTotale { get { return Resumes.Sum(r => r.Value); } }
        public IEnumerable<Resume> Resumes { get; set; }
    }
