    public void DisposeAllButThis(Form parentForm)
        {
            foreach (Form frm in Parent.MdiChildren)
            {
                if (frm.GetType() != Parent.GetType()
                    && frm != Parent)
                {
                    frm.Close();
                }
            }
        }
