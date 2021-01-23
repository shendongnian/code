    void m_MouseMove(object sender, Point p)
    {
        Point pt = this.PointToClient(p);
        if (this.ClientSize.Width >= pt.X &&
                        this.ClientSize.Height >= pt.Y &&
                        pt.X > 0 && pt.Y > 0)
        {
            this.Activate();
        }
    }
