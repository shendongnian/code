    MissingMemberException: Public member 'IDontExist' on type 'IEntity2' not found.
       at Microsoft.VisualBasic.CompilerServices.Symbols.Container.GetMembers(String& MemberName, Boolean ReportErrors)
       at Microsoft.VisualBasic.CompilerServices.NewLateBinding.ObjectLateGet(Object Instance, Type Type, String MemberName, Object[] Arguments, String[] ArgumentNames, Type[] TypeArguments, Boolean[] CopyBack)
       at Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(Object Instance, Type Type, String MemberName, Object[] Arguments, String[] ArgumentNames, Type[] TypeArguments, Boolean[] CopyBack)
       at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
       at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
       at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source) 
