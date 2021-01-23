       Originator<string> org = new Originator<string>();
       org.State = "Old State";
       // Store internal state in the caretaker object
       Caretaker<string> caretaker = new Caretaker<string>();
       caretaker.Memento = org.SaveMemento();
       Console.WriteLine("This is the old state: {0}", org.State);
       org.State = "New state";
       Console.WriteLine("This is the new state: {0}", org.State);
       // Restore saved state from the caretaker
       org.RestoreMemento(caretaker.Memento);
       Console.WriteLine("Old state was restored: {0}", org.State);
       // Wait for user
       Console.Read();
