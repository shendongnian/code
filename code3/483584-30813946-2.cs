            game.OnMouseLeftButtonDown += (sender, a) =>
            {
                var xy = GetChessboardPositionByScreenPosition(a.XY);
                if (IsInside(xy))
                {
                    var args = new ChessboardEventArgs { Position = xy };
                    OnMouseDown.SafeInvokeWithCancel(this, args);
                    a.CancelFutherProcessing();
                }
            };
