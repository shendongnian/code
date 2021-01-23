        private MyObject[] sort(List<MyObject> input) {
            //sort input with it's key
            MyObject[] gg = input.ToArray();
            for (int a = 0; a < input.Count; a++) {
                for (int b = a + 1; b < input.Count; b++) {
                    if (gg[a].Key > gg[b].Key) {
                        MyObject temp = gg[a];
                        gg[a] = gg[b];
                        gg[b] = temp;
                    }
                }
            }
            //sort input, if key is same => sort the date
            for (int a = 0; a < input.Count; a++) {
                int indStart = a;
                int indEnd = a;
                for (int b = a + 1; b < input.Count; b++) {
                    if (gg[a].Key == gg[b].Key) {
                        indEnd++;
                    } else {
                        b = input.Count;
                    }
                }
                a = indEnd;
                for (int c = indStart; c <= indEnd; c++) {
                    for (int d = c + 1; d <= indEnd; d++) {
                        if (gg[c].Day > gg[d].Day) {
                            MyObject temp = gg[c];
                            gg[c] = gg[d];
                            gg[d] = temp;
                        }
                    }
                }
            }
            return gg;
        }
        private List<MyObject> Comparer(List<MyObject> listA, List<MyObject> listB) {
            List<MyObject> output = new List<MyObject>();
            //if you sure that the list was sorted, u just remove the sort function
            MyObject[] ff = sort(listA);
            MyObject[] gg = sort(listB);
            Boolean[] masuk = new Boolean[gg.Length];
            //foreach element in listA, search the changes in input
            for (int a = 0; a < listA.Count;a++ ) {
                //find element in input which contains the changes of element in listA
                Boolean ins = false;
                for (int b = 0; b < listB.Count;b++ ) {
                    if (masuk[b])
                        continue;
                    if (ff[a].Key >= gg[b].Key) {
                        if (ff[a].Key == gg[b].Key && ff[a].Day == gg[b].Day){
                            masuk[b] = true;
                            if (gg[b].Value != ff[a].Value) {
                                output.Add(new MyObject() { Key = gg[b].Key, Day = gg[b].Day, Value = gg[b].Value - ff[a].Value });
                                b = listB.Count;
                            }
                            ins = true;
                        }
                    } else {
                        b = listB.Count;
                    }
                }
                if (!ins) {
                    output.Add(new MyObject() { Key = ff[a].Key, Day = ff[a].Day, Value = -ff[a].Value });
                }
            }
            for (int a = 0; a < gg.Length;a++ ) {
                if(!masuk[a]){
                    output.Add(new MyObject() { Key = gg[a].Key, Day = gg[a].Day, Value = gg[a].Value });
                }
            }
            return output;
        }
