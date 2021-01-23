    var angles = (angles.Count >= 2 && sides.Count >= 1);
    var sides = (angles.Count == 1 && sides.Count >= 2);
    if (angles)
    { calculateTriangleFromAngles(); }
    else if (sides)
    { calculateTriangleFromAngles(); }
    else
    { MsgBox.... }
