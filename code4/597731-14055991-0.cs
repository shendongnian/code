    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace DataSetComparison
    {
        class Program
        {
            static void Main( string[] args )
            {
                var l_table1 = new DataTable();
                l_table1.Columns.Add( "Key", typeof( int ) );
                l_table1.Columns.Add( "Name", typeof( string ) );
                l_table1.Columns.Add( "Age", typeof( int ) );
                var l_table2 = new DataTable();
                l_table2.Columns.Add( "Key", typeof( int ) );
                l_table2.Columns.Add( "Name", typeof( string ) );
                l_table2.Columns.Add( "Age", typeof( int ) );
                l_table1.Rows.Add( l_table1.NewRow() );
                l_table1.Rows[l_table1.Rows.Count - 1]["Key"] = 0;
                l_table1.Rows[l_table1.Rows.Count - 1]["Name"] = "Alfred Harisson";
                l_table1.Rows[l_table1.Rows.Count - 1]["Age"] = 36;
                l_table1.Rows.Add( l_table1.NewRow() );
                l_table1.Rows[l_table1.Rows.Count - 1]["Key"] = 1;
                l_table1.Rows[l_table1.Rows.Count - 1]["Name"] = "Matthew George";
                l_table1.Rows[l_table1.Rows.Count - 1]["Age"] = 41;
                l_table1.Rows.Add( l_table1.NewRow() );
                l_table1.Rows[l_table1.Rows.Count - 1]["Key"] = 2;
                l_table1.Rows[l_table1.Rows.Count - 1]["Name"] = "Franklin Henry";
                l_table1.Rows[l_table1.Rows.Count - 1]["Age"] = 33;
                l_table2.Rows.Add( l_table2.NewRow() );
                l_table2.Rows[l_table2.Rows.Count - 1]["Key"] = 0;
                l_table2.Rows[l_table2.Rows.Count - 1]["Name"] = "Alfred Harisson";
                l_table2.Rows[l_table2.Rows.Count - 1]["Age"] = 36;
                l_table2.Rows.Add( l_table2.NewRow() );
                l_table2.Rows[l_table2.Rows.Count - 1]["Key"] = 1;
                l_table2.Rows[l_table2.Rows.Count - 1]["Name"] = "Matthew George";
                l_table2.Rows[l_table2.Rows.Count - 1]["Age"] = 42; // Record 1 "modified"
                // Record 2 "deleted"
                // Record 3 "added":
                l_table2.Rows.Add( l_table2.NewRow() );
                l_table2.Rows[l_table2.Rows.Count - 1]["Key"] = 3;
                l_table2.Rows[l_table2.Rows.Count - 1]["Name"] = "Lester Kulick";
                l_table2.Rows[l_table2.Rows.Count - 1]["Age"] = 33;
                // Using table 1 as the control, find changes in table 2
                // Find deleted rows:
                var l_table2Keys = l_table2.Select().Select( ( r ) => (int) r["Key"] );
                var l_deletedRows = l_table1.Select().Where( ( r ) => !l_table2Keys.Contains( (int) r["Key"] ) );
                foreach ( var l_deletedRow in l_deletedRows )
                    Console.WriteLine( "Record " + l_deletedRow["Key"].ToString() + " was deleted from table 2." );
                // Find added rows:
                var l_table1Keys = l_table1.Select().Select( ( r ) => (int) r["Key"] );
                var l_addedRows = l_table2.Select().Where( ( r ) => !l_table1Keys.Contains( (int) r["Key"] ) );
                foreach ( var l_addedRow in l_addedRows )
                    Console.WriteLine( "Record " + l_addedRow["Key"].ToString() + " was added to table 2." );
                // Find modified rows:
                var l_modifiedRows = l_table2.Select()
                                             .Join(
                                                l_table1.Select(),
                                                r => (int) r["Key"],
                                                r => (int) r["Key"],
                                                ( r1, r2 ) => new
                                                    {
                                                        Row1 = r1,
                                                        Row2 = r2
                                                    } )
                                            .Where(
                                                values => values.Row1 != null &&
                                                          values.Row2 != null &&
                                                          !( values.Row1["Name"].Equals( values.Row2["Name"] ) &&
                                                             values.Row1["Age"].Equals( values.Row2["Age"] ) ) )
                                            .Select( values => values.Row2 );
                foreach ( var l_modifiedRow in l_modifiedRows )
                    Console.WriteLine( "Record " + l_modifiedRow["Key"].ToString() + " was modified in table 2." );
                Console.WriteLine( "Press any key to quit..." );
                Console.ReadKey( true );
            }
        }
    }
