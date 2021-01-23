    public string[] GetDiceCombinations(int noOfDicesOrnoOfTossesOfDice)
            {
                noOfDicesOrnoOfTossesOfDice.Throw("noOfDicesOrnoOfTossesOfDice",
                    n => n <= 0);
                List<string> values = new List<string>();
                this.GetDiceCombinations_Recursive(noOfDicesOrnoOfTossesOfDice, 1, "",
                    values);
                return values.ToArray();
            }
            private void GetDiceCombinations_Recursive(int size, int index, string currentValue,
                List<string> values)
            {
                if (currentValue.Length == size)
                {
                    values.Add(currentValue);
                    return;
                }
                for (int i = index; i <= 6; i++)
                {
                    this.GetDiceCombinations_Recursive(size, i, currentValue + i, values);
                }
            }
