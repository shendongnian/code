    for (i = 0; i < this.Count; i++)
        {
            gpaToAdd = 0.0; 
            Course c = this[i]; 
            gpaToAdd = GradePoints(c.Grade);
            if (c.Grade == null || c.Grade == "W") continue;
            if (bForgiven == false)
            {
                int nRep = FindCourse(c.Number, i + 1);
                if (nRep > 0)
                {
                    Course x = this[i + 1];
                    if(GradePoints(this[nRep].Grade > GradePoints(c.Grade)))
                        gpaToAdd = GradePoints(x.Grade); 
                    // This means we forgive only one grade
                    bForgiven = true;
                    // This will restart the for loop at the next item, 
                    // presumably skipping whatever code you left out
                    // below
                    continue; 
                }
            }
        // Something else is going on down here that you didnt show us-
        // my guess is something like:
        gpa = gpaToAdd + gpa;
        // but it is getting skipped when a grade is forgiven
