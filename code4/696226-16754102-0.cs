    public void RepositionButton(int horizontalSpacing)
    {
        int newXPos = lblLabel.Position.X - btnButton.Width - horizontalSpacing;
        int newYPos = lblLabel.Position.Y;
        btnButton.Position = new Point(newXPos, newYPos);
    }
