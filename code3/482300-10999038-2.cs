    public void toggleNote(int index)
    {
        if (index < 0 || index >= l1NoteData.Length)
        {
            Debug.WriteLine("Out of bounds access attempted: " + index);
            return;
        }
    
        l1NoteData[index] = !l1NoteData[index]
    }
