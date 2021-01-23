    public string Phase(int phase)
    {
        switch(phase)
        {
            default:
                return "Phase 1";
            case 2:
                return "Phase 2";
        }
        // Or just
        // return "Phase " + phase.ToString();
    }
