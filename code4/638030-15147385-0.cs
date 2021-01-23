    public void ChangeChartSize(int width, int height)
            {
                this.Size = new Size(width, height);
                chart1.Size = new Size(width, height);
                chart1.Invalidate();
            }
