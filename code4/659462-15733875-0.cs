    object newObject = Activator.CreateInstance(myType);
    
    var publishMethod = typeof(MessageProducer).GetMethod("Publish");
    var publishMethodWithCorrectType = publishMethod.MakeGenericMethod(new Type[] { myType });
    
    publishMethodWithCorrectType.Invoke(messageProducer, new object[]{newObject});
