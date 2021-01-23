        private HyperLink FindControl(ControlCollection page, string myId)
        {
            foreach (Control c in page)
            {
                if ((HyperLink)c.ID == myId)
                {
                    return (HyperLink)c;
                }
                if (c.HasControls())
                {
                    FindControl(c.Controls, myId);
                }
            }
            return null; //may need to exclude this line
        }
