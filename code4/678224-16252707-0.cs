    public static List<DependencyObject> List_Logical( DependencyObject P_Parent )
			{
				var L_List = new List<DependencyObject>
							{
								P_Parent
							};
				foreach ( var L_Parent in LogicalTreeHelper.GetChildren( P_Parent ).OfType<DependencyObject>() )
				{
					L_List.AddRange( List_Logical( L_Parent ) );
				}
				return L_List;
			}
