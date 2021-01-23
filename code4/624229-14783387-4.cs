class SafeClass
{
    String name="";
    Integer age=0;
    public void setName(String newName)
    {
        assert(newName != null)
        name=newName;
    }// follow this pattern for age
    ...
    public String toString() {
        String s="Safe Class has name:"+name+" and age:"+age
    }
}
