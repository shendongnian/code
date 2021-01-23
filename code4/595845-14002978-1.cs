    public async void LoadData()
    {
        bool HasNote = await brain.GetNotesRepoFile().ReadFile();
        if (HasNote)
        {
            for (int i = 0; i < brain.GetNotesRepoFile().notesRepository.Count; i++)
            {
                    //Your code
            }
        }
     }
