    QRCodeEncoder qrCE = new QRCodeEncoder();
    qrCE.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
    qrCE.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
    qrCE.QRCodeVersion = 1;
    
    picQRCode.Image = qrCE.Encode(memBarcodeDataForPrint.Text, System.Text.Encoding.UTF8);
