     private void button1_Click(object sender, EventArgs e)
        {
            List<int> indexes = new List<int>();
            Calculate(180, 0, 0, array, indexes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indexes.Count; i++)
            {
                sb.Append(array[indexes[i]].ToString() + " [" + indexes[i].ToString() + "], ");
            }
            MessageBox.Show(sb.ToString());
        }
        bool Calculate(int goal, int sum, int index, int[] arr, List<int> indexes)
        {
            if (index > arr.Length - 1)
                return false;
            sum += arr[index];
            if (sum == goal)
            {
                indexes.Add(index);
                return true;
            }
            else if (sum > goal)
                return false;
            else
            {
                bool result = false;
                int count = 0;
                while (!(result = Calculate(goal, sum, index + ++count, arr, indexes)) && (index + count) < arr.Length) ;
                if (result)
                {
                    indexes.Add(index);
                    return true;
                }
                else
                    return false;
            }
        }
