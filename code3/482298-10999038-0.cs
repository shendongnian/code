    public void toggleNote(int index)
    {
        if (index < 0 || index >= l1NoteData.Length)
        {
            Debug.WriteLine("Out of bounds access attempted.");
            return;
        }
    
        l1NoteData[index] = !l1NoteData[index]
    }
