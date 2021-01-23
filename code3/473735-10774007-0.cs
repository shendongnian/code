    struct Chord
    {
        public string Name;
    }
    
    ...
    
    Chord cMajor = new Chord;
    cMajor.Name = "C Major";
    Chord cMinor = cMajor; // Make a copy of the Chord instance
    cMinor.Name = "C Minor";
    
    Assert.That(cMajor.Name, Is.EqualTo("C Major")); // Assertion succeeds
