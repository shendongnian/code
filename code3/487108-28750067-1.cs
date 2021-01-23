    public MyDTO toObject() {
	  try {
        var methodInfo = MethodBase.GetCurrentMethod();
	    if (methodInfo.DeclaringType != null) {
	      var fullName = methodInfo.DeclaringType.FullName + "." + this.dtoName;
	      Type type = Type.GetType(fullName);
	      if (type != null) {
	        var obj = JsonConvert.DeserializeObject(payload);
          //var obj = JsonConvert.DeserializeObject<type.MemberType.GetType()>(payload);  // <--- type ?????
	          ...
	      }
	    }
        // Example for java..   Convert this to C#
		return JSONUtil.fromJSON(payload, Class.forName(dtoName, false, getClass().getClassLoader()));
	  } catch (Exception ex) {
        throw new ReflectInsightException(MethodBase.GetCurrentMethod().Name, ex);
	  }
	}
