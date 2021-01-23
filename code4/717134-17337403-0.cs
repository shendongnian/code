    public void DrawWindow(Rect p_PositionAndSize, string p_Button2Text = "NotInUse", Action p_Button2Action = null)
    {
        if (p_Button2Action == null)
            p_Button2Action = delegate{ Debug.Log("NotInUse"); }
        ...
    }
