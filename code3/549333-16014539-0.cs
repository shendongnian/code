    var vy = new List<double>();
    var vx = new List<svm_node[]>();
    foreach (var line_i in your_data_source)
    {
       vy.Add(line_i.Y); // double value representing the class for the given experience
       
       List<svm_node> x = new List<svm_node>();
       for(int j = 0 ; j < NB_ATTRIBUTES ; j++) // Save values for each attributes
       {
          var attributeValue = line_i.X[j]; // value of the corresponding attribute
          x.Add( new svm_node() { index = j, value = attributeValue });
       }
       vx.Add(x.ToArray());
    }
    var data_set= new svm_problem();
    data_set.l = vy.Count;
    data_set.x = vx.ToArray();
    data_set.y = vy.ToArray();
    var svm = new C_SVC(data_set, [most_appropriate_Kernel], c_parameter);
