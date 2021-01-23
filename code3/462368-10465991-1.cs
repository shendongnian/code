    namespace StackOverflowTestCode
    {
        using System.Data;
        using Microsoft.VisualStudio.TestTools.UnitTesting;
    
        [TestClass]
        public class RandomTests
        {
            [TestMethod]
            public void DataTableUpdate_Test()
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add( "Title", typeof( string ) );
                dataTable.Columns.Add( "Quantity", typeof( int ) );
                dataTable.Rows.Add( "TitleOne", 0 );
                dataTable.Rows.Add( "TitleTwo", 0 );
                dataTable.Rows.Add( "TitleThree", 0 );
                DataRow[] rowsToUpdate = 
                    dataTable.Select( "Title = 'TitleTwo'" );
                if( rowsToUpdate != null && rowsToUpdate.Length == 1 )
                {
                    rowsToUpdate[ 0 ][ "Quantity" ] = 
                        rowsToUpdate[ 0 ].Field<int>( "Quantity" ) + 1;
                }
                // The right row was updated.
                Assert.AreEqual( 1, dataTable.Rows[ 1 ][ "Quantity" ] );
                // The other rows were not updated.
                Assert.AreEqual( 0, dataTable.Rows[ 0 ][ "Quantity" ] );
                Assert.AreEqual( 0, dataTable.Rows[ 2 ][ "Quantity" ] );
            }
        }
    }
