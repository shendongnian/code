    if (links.Count > 0)
    {
        links[0].InvokeMember("click");
        links.RemoveAt(0);
    }
    // else timer.Stop();
