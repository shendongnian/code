    void ClearControls()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            foreach (Control cc in Controls)
            {
                if (cc.Name.Contains(LINK_LABEL_FAMILY) || (cc.Name.Contains(LABEL_FAMILY)))
                {
                    Controls.RemoveByKey(cc.Name);
                }
            }
        }
    }
