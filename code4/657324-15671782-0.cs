	public static partial class DataReaderExtensions {
		/// <summary>
		///	<para>Copy data to target object</para>
		///	<para>Class which implements IDataRecord usually also implements IDataReader</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <param name="target"></param>
		/// <returns>the count of field or property copied</returns>
		public static int CopyTo<T>(this IDataRecord data, T target) {
			return (
				from column in
					Enumerable.Range(0, data.FieldCount).Select(
						(x, i) => new {
							DataType=data.GetFieldType(i),
							ColumnName=data.GetName(i)
						}
						)
				let type=target.GetType()
				from member in type.GetMembers()
				let typeMember=
					member is PropertyInfo
						?(member as PropertyInfo).PropertyType
						:member is FieldInfo
							?(member as FieldInfo).FieldType
							:default(MemberInfo)
				where typeMember==column.DataType
				let name=member.Name
				where name==column.ColumnName
				let invokeAttr=
					BindingFlags.SetProperty|BindingFlags.SetField|
					BindingFlags.NonPublic|BindingFlags.Public|
					BindingFlags.Instance
				select type.InvokeMember(name, invokeAttr, default(Binder), target, new[] { data[name] })
				).Count();
		}
	}
