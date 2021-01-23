    private void ScrollBlock()
    {
        for (int x = 0; x < _boardSize; x++) {
            for (int y = 0; y < _boardSize; y++) {
                if (_activeBoard[x, y]) {
                    _activeBoard[x, y] = false;
                    int newX = x + 1;
                    int newY = y;
                    if (newX == _boardSize) {
                        newX = 0;
                        newY = (newY + 1) % _boardSize;
                    }
                    _inactiveBoard[newX, newY] = true;
                }
            }
        }
        SwapBoards();
    }
