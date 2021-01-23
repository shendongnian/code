I had the exact same problem as you have when newAreaItem == null is true.
The problem comes from the fact that the item used in the LINQ cannot be null. Thus, when  newAreaItem == null is true it means that newAreaItem is null and this leads to the error being thrown.
All you can do in my opinion is, after checking newAreaItem == null, to set the newAreaItem to a new empty object of that type if newAreaIteam is null. The newAreaItemIsNull condition will still be in place, thus the 
    (cm.AreaItem != null && cm.AreaItem.Id == newAreaItem.Id)
in your code below will still not be evaluated if newAreaItem is null.
    context.CharacteristicMeasures.
                                     FirstOrDefault(cm => cm.Charge == null &&
                                                          cm.Characteristic != null && cm.Characteristic.Id == c.Id &&
                                                          cm.Line != null && cm.Line.Id == newLine.Id &&
                                                          cm.ShiftIndex != null && cm.ShiftIndex.Id == actShiftIndex.Id &&
                                                          (newAreaItem == null ||
                                                           (cm.AreaItem != null && cm.AreaItem.Id == newAreaItem.Id)));
