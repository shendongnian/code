    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
    {
        TextPointer line = richTextBox1.CaretPosition.GetLineStartPosition(0);
        if (line.GetOffsetToPosition(richTextBox1.CaretPosition) > 60)
        {
            line.GetPositionAtOffset(60, LogicalDirection.Forward).InsertLineBreak();
        }
    }
