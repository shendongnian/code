    using System.Linq;
    for (int i = 0; i < Counter; i++)
    {
       bool deptExists = list.Exists(ele => ele == result[i].department);
       if(!deptExists){
        list.Add(result[i].department);
       }
    }
