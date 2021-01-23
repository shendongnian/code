    private void Backward_Click(object sender, EventArgs e)
        {
            try
            {
                if (simpleStack.Count != 0)
                {
                    //simpleStack.Pop();    // Remove this line
                    string open = simpleStack.Pop();
                    PopulateListView(open);
                    complicatedStack.Push(open);
                }
                else if (simpleStack.Count == 0)
                {
                    Backward.Enabled = false;
                }
            }
        }
