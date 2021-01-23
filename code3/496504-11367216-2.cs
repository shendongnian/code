    if (GradePoints(trans[nRep].Grade) > GradePoints(c.Grade))
    {
        gpaToAdd = GradePoints(x.Grade);
        // This means we forgive only one grade
        bForgiven = true;
        continue;
    }
