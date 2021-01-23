        private void QaControl( string _itemNo, int _curIndex ) {
            List<QaControlPoint> list = new List<QaControlPoint>();          //remove old ones from list         
            if ( listBox1.DataSource != null ) {
                List<QaControlPoint> oldList = (List<QaControlPoint>) listBox1.DataSource;
                list.AddRange( oldList );
                for ( int n = listBox1.Items.Count - 1; n >= 0; --n ) {
                    QaControlPoint qcp = (QaControlPoint) listBox1.Items[n];
                    if ( _boxList.IndexOf( qcp.link_box ) >= _curIndex )
                        list.Remove( qcp );
                }
            }
            string fs = service.getQa( Int32.Parse( _itemNo ), "R" );
            string[] temp = fs.Split( '@' );
            for ( int a = 0; a < temp.Length - 1; a++ )
                list.Add( new QaControlPoint( temp[a], _boxList[_curIndex] ) );
            listBox1.DataSource = list;
        }
