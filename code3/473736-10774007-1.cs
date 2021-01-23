    class Chord
    {
        public string Name;
    }
    
    ...
    
    Chord cMajor = new Chord;
    cMajor.Name = "C Major";
    Chord cMinor = cMajor; // No copy of the Chord instance, just another reference
    cMinor.Name = "C Minor";
    
    Assert.That(cMajor.Name, Is.EqualTo("C Major")); // Assertion fails
    Assert.That(cMajor.Name, Is.EqualTo("C Minor")); // Assertion succeeds
