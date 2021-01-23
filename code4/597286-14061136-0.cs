        void AnswerItemChanged(object sender, PropertyChangedEventArgs e)
        {
        if (e.PropertyName == "AnswerChecked")
        {
            bool hasAnswer = false;
            foreach(Answer answer in Answers)
            {
                if (answer.AnswerChecked == true)
                {
                    hasAnswer = true;
                    break;
                }
            }
            foreach (Answer answer in Answers)
            {
                substep.PropertyChanged -= AnswerItemChanged;
                   
                if (hasAnswer && !answer.AnswerChecked )
                {
                    answer.AllowAnswer = false;
                }
                else 
                {
                    answer.AllowAnswer = true;
                }
                
                substep.PropertyChanged += AnswerItemChanged;
            }
        }
        }
