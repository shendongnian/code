        public enum DifficultyEnum {
            NULL,
            Easy,
            Medium,
            Hard
        }
        public DifficultyEnum GetDifficulty()
        {
            var difficulty = DifficultyEnum.NULL;
            var selItem = listBox1.SelectedItem.ToString();
            Enum.TryParse<DifficultyEnum>(selItem, out difficulty);
            return difficulty;           
        }
