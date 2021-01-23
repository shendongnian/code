    public class Trial {
        public int Id { get; set; }
        public bool WasResponseCorrect { get; set; } // if this is in every type of trial
        // anything else that is common to ALL trial types
    }
    public class TrialA : Trial {
        public string WhichButtonWasPressed { get; set; }
        public double SimulusLevel { get; set; }
    }
    public class TrialB : Trial {
        public string ColorPresented { get; set; }
        public char LetterPresented { get; set; }
        public char LetterGuessed { get; set; }
    }
