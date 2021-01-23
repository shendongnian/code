        if (flag == true)
        {
             Segments tempSegments = new Segments();
             //The lists are now complete for the first segment.
             list1.Add(longList.one[i]);
             list2.Add(longList.two[i]);
             list3.Add(longList.three[i]);
             list4.Add(longList.four[i]);
             //created a copy of the class properties
             tempSegments.List1 = new List<double>(list1);
             tempSegments.List2 = new List<double>(list2);
             tempSegments.List3 = new List<double>(list3);
             tempSegments.List4 = new List<double>(list4);
             //Add to List<Segments>
             segments.Add(tempSegments)
             //Clear lists in order to move on to creating next segment of the longList.
             list1.Clear();
             list2.Clear();
             list3.Clear();
             list4.Clear();
             break;
        }
