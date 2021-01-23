    do
    {
        line = SR.ReadLine();
        if ((line != null))
        {
            if(!line.StartsWith("Microsoft Windows", StringComparison.OrdinalIgnoreCase))
            {
                VerbindingOutput.Text = VerbindingOutput.Text + line + Environment.NewLine;
            }
        }
    } while (line != null);
