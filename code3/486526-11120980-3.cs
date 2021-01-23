        private void MoveCanvas(List<double> list, double dYpuntero)
        {
            if (HasLessThan100(list))
            {
                list.Add((double)dYpuntero);
            }
            else return;
        }
