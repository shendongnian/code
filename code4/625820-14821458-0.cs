        for (int i = 0; i < int.Parse(radTextBoxFloodRequests.Text); i++)
        {
            int x = i; // This was in the wrong scope
            tasks[i] = new Task<int>(() =>
            {
                int result = TaskRequestWithResult(int.Parse(radTextBoxFirstNumber.Text), int.Parse(radTextBoxSecondNumber.Text), int.Parse(radTextBoxFloodDelay.Text), x);
                return result;
            });
        }
