     private void MoveDownEnabled_Click(object sender, EventArgs e)
     {
        Panel Current = panels.get(index);
        if(index < panels.Count)
        {
            // Grab the next item.
            Panel Next = panels.get(++ index);
            // And this part is up to you!
        }
     }
