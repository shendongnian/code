    foreach (string s in splitString)
    {
        string trimmedS = s.Trim();
        if (trimmedS != "")
        {
            int selectionStart = -1;
            if (trimmedS.ToLower == "football") // Find the string you want to color
                selectionStart = allInput.Count;
            allInput.Add(s);
            if (selectionStart != -1)
            {
                rtbInput.SelectionStart = selectionStart; // Select that string on your RTB
                rtbInput.SelectionLength = trimmedS.Length;
                rtbInput.SelectionColor = myCustomColor; // Set your color here
            }
        }
    }
