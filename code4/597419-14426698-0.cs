    public char Peek()
    {
        if (this.CharacterBuffer.Count > 0)
            return this.CharacterBuffer.Peek();
        char Character
        try
        {
            Character = Convert.ToChar(this.Reader.Read());
        }
        catch (OverflowException)
        {
            throw new EndOfStreamException();
        }
        this.CharacterBuffer.Enqueue(Character);
        return Character;
    }
