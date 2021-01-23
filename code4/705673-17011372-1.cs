    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        // reset all the trees:
        for (int j = 0; j < trees.Length; j++) 
        {
            trees[j].isHit = false;
        }
        // see which trees are hit:
        mouseX = e.X;
        mouseY = e.Y;
        bool isClicked = false;
        for (int i = 0; i < trees.Length; i++)
        {
            isClicked = trees[i].checkClick(mouseX, mouseY);
            if (isClicked)
            {
                // initially true, but might be reset below if the 
                // back button was hit instead?
                trees[i].isHit = true;
                isHit = isClicked;
                if(mouseX >= 5 && mouseX <= backButton.Width)
                {                        
                    if(mouseY >= 5 & mouseY <= backButton.Height)
                    {
                        goBack = true;
                        trees[i].isHit = false;
                        isHit = false;
                        HideLabels();
                    }
                }
                loadTree(trees[i]);
            }
        }
    }
