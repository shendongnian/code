    void ListMissingResearch(Research r)
    {
        for (Research sub in r.requiredResearches)
        {
            if (!sub.completed)
            {
                // print message saying "Research <r> requires research <sub>"
                ListMissingResearch(sub); // list any missing sub-sub-research
            }
        }
    }
