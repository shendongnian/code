    if (checkBox1.CheckState == CheckState.Checked)
        {
            myLine[lineCount] = new Line(); //instantiate the array element
            myLine[lineCount].setPoint(new Point(e.X, e.Y));
            ++pointCount;
            if (pointCount == 2)
            {
                pointCount = 0;
                ++lineCount;
            }
    }
